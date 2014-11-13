using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace Translation
{
    public class TranslationModel:ObservableObject
    {
        private string _context;
        public string Context {
            get { return _context; }
            set
            {
                _context = value;
                this.RaisePropertyChanged(() => Context);
            }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                this.RaisePropertyChanged(() => Result);
            }
        }

        private string _fromLanguage;

        public string FromLanguage
        {
            get { return _fromLanguage; }
            set
            {
                _fromLanguage = value;
                
                this.RaisePropertyChanged(()=>FromLanguage);
            }
        }

        private string _toLanguage;

        public string ToLanguage
        {
            get { return _toLanguage; }
            set
            {
                _toLanguage = value;
                this.RaisePropertyChanged(() => ToLanguage);
            }
        }
    }
}
