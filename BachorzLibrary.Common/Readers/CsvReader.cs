using BachorzLibrary.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BachorzLibrary.Common.Readers
{
    public class CsvReader<R> where R : class
    {
        public string[] DataRows { get; set; }
        public string[] HeaderNames { get; set; }
        public char ColumnSeparator { get; set; } = ';';

        public virtual Func<string[], R> ResultDataInterpreter { get; set; } = result => null;

        public IEnumerable<R> Read()
        {
            if (DataRows.IsNullOrEmpty())
            {
                throw new ArgumentException("Nie podano danych do rozbiórki", nameof(DataRows));
            }

            if (ResultDataInterpreter == null)
            {
                throw new ArgumentNullException(nameof(ResultDataInterpreter), "CSV data interpreter not implemented");
            }

            foreach (var dataRow in HeaderNames.IsNotNullOrEmpty() ? DataRows.Skip(1) : DataRows)
            {
                var chunks = dataRow.Split(ColumnSeparator);
                yield return ResultDataInterpreter(chunks);
            }
        }

        public bool HeadersAreCorrect
        {
            get
            {
                if (HeaderNames.IsNullOrEmpty())
                {
                    return true;
                }

                var headersFromDataRow = DataRows?.FirstOrDefault()?.Split(ColumnSeparator);

                if (headersFromDataRow?.Count() != HeaderNames?.Length)
                {
                    return false;
                }

                for (int i = 0; i < HeaderNames?.Length; i++)
                {
                    if (!headersFromDataRow[i].Equals(HeaderNames[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }

    public class CsvReader : CsvReader<string[]>
    {
        public override Func<string[], string[]> ResultDataInterpreter => result => result;
    }
}
