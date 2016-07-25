using System;

namespace FxApp.Base.ViewModels
{
    interface IItem
    {
        string Name { get; set; }

        decimal Spread { get; set; }

        DateTime ActualDateTime { get; set; }

        decimal FieldGreen1 { get; set; }
        decimal FieldGreen2 { get; set; }

        decimal FieldGreen3 { get; set; }

        decimal FieldRed1 { get; set; }
        decimal FieldRed2 { get; set; }
        decimal FieldRed3 { get; set; }
    }
}
