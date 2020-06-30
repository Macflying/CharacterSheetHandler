using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CharacterSheetHandler.Models.Tests
{
    internal class TestFailedException : Exception
    {
        private string _file;
        private string _method;
        private int _line;
        private string _message;

        public TestFailedException(string message)
        {
            _message = message;
        }

        public TestFailedException([CallerFilePath] string file = null, [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
        {
            _file = file;
            _method = method;
            _line = line;
        }

        public override string Message => 
            string.IsNullOrEmpty(_message)
            ? $"{_file}.{_method} failed at line {_line}"
            : _message;
    }
}
