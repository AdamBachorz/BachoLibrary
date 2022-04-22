using BachorzLibrary.DAL.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BachorzLibrary.DAL;
using System.ComponentModel;
using BachorzLibrary.DAL.DAO;

namespace BachorzLibrary.Tests.DAL.NHibernate
{
    [TestFixture]
    public class NHibernateTests
    {
        IFluentNHibernateCustomConfig _config;
        INHibernateHelper _nHibernateHelper;
        IBaseDao<User> _dao;

        [Serializable]
        class User : Entity
        {
            [DisplayName("Nazwa użytkownika")]
            public virtual string UserName { get; set; }
            public virtual string PasswordHash { get; set; }
            public virtual string Email { get; set; }
            public virtual UserRole UserRole { get; set; }

            public virtual string Greeting => $"Witaj, {UserName}!";
        }

        class UserMapping : FluentNHibernateEntityMapping<User>
        {
            public UserMapping() : base("app_user")
            {
                Map(x => x.UserName, "user_name");
                Map(x => x.PasswordHash, "password_hash");
                Map(x => x.Email, "email");
                Map(x => x.UserRole, "id_user_role").CustomType<UserRole>();
            }
        }

        class UserDao : NHibernateBaseDao<User>
        {
            public UserDao(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
            {
            }

        }

        [SetUp]
        public void Setup()
        {
            _config = new FluentNHibernateCustomConfig
            {
                DataBase = DataBase.PostgreSQL,
                ConnectionString = "User ID=ikpsbjrr;Password=PD3VF_f8PgDU6GMEFcsDwuxsOrSomjnT;Host=tai.db.elephantsql.com;Port=5432;Database=ikpsbjrr;Pooling=true;",
                Mapping = x => x.FluentMappings.Add<UserMapping>().Conventions.Add<FluentNHibernateEnumConvention>()
            };
            _nHibernateHelper = new NHibernateHelper(_config);
            _dao = new UserDao(_nHibernateHelper);
        }

        [Test]
        public void ShouldNotThrow_GetOneById()
        {
            Assert.DoesNotThrow(() => _dao.GetOneById(1));
        }

        [Test]
        public void ShouldReturnEntity_GetOneById()
        {
            var entity = _dao.GetOneById(1);
            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.Id, Is.EqualTo(1));
            Assert.That(entity.PasswordHash, Is.Not.Empty);
            Assert.That(entity.UserName, Is.Not.Empty);
            Assert.That(entity.UserRole, Is.EqualTo(UserRole.Administrator));
            Assert.That(entity.Email, Is.Not.Empty);
            Assert.That(entity.Greeting, Is.Not.Empty);
        }
    }
}
