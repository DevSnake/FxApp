using System;
using BlackBee.Common;

namespace FxApp.Base.ViewModels
{
    public class ItemViewModel:XBlackObject,
        IItem
    {
        private string _name;
        private decimal? _spread;
        private DateTime? _actualDateTime;
        private decimal? _fieldGreen1;
        private decimal? _fieldGreen2;
        private decimal? _fieldGreen3;
        private decimal? _fieldRed1;
        private decimal? _fieldRed2;
        private decimal? _fieldRed3;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public decimal? Spread
        {
            get { return _spread; }
            set
            {
                _spread = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? ActualDateTime
        {
            get { return _actualDateTime; }
            set
            {
                _actualDateTime = value; 
                NotifyPropertyChanged();
            }
        }

        public decimal? FieldGreen1
        {
            get { return _fieldGreen1; }
            set
            {
                _fieldGreen1 = value; 
                NotifyPropertyChanged();
            }
        }

        public decimal? FieldGreen2
        {
            get { return _fieldGreen2; }
            set
            {
                _fieldGreen2 = value;
                NotifyPropertyChanged();
            }
        }

        public decimal? FieldGreen3
        {
            get { return _fieldGreen3; }
            set
            {
                _fieldGreen3 = value;
                NotifyPropertyChanged();
            }
        }

        public decimal? FieldRed1
        {
            get { return _fieldRed1; }
            set
            {
                _fieldRed1 = value;
                NotifyPropertyChanged();
            }
        }

        public decimal? FieldRed2
        {
            get { return _fieldRed2; }
            set
            {
                _fieldRed2 = value;
                NotifyPropertyChanged();
            }
        }

        public decimal? FieldRed3
        {
            get { return _fieldRed3; }
            set
            {
                _fieldRed3 = value;
                NotifyPropertyChanged();
            }
        }
    }
}
