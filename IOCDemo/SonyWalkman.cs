
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo
{
    public class SonyWalkman
    {
        private readonly ITapeCassette _tapeCassette;

        public SonyWalkman(ITapeCassette tapeCassette)
        {
            this._tapeCassette = tapeCassette;
        }

        public string Paly()
        {
            return string.Format("Now Playing {0}-{1}", _tapeCassette.Artist, _tapeCassette.Album);
        }
    }
}
