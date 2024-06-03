﻿using System.ComponentModel;

namespace Core.Data
{
    public enum EstimatedValueSavings
    {
        [Description("More than 5 million")]
        MoreThanFiveMillion,
        [Description("1-5 million")]
        LessThanFiveMillion
        // add more types later
    }
}
