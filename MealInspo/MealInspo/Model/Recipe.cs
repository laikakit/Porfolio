using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MealInspo
{
    public class Recipe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [PrimaryKey]
        public string label { get; set; }
        public string image { get; set; }
        [TextBlob("dietLabelsBlobbed")]
        public List<string> dietLabels { get; set; }
        public string dietLabelsBlobbed { get; set; }
        [TextBlob("healthLabelsBlobbed")]
        public List<string> healthLabels { get; set; }
        public string healthLabelsBlobbed { get; set; }
        [TextBlob("ingredientLinesBlobbed")]
        public List<string> ingredientLines { get; set; }
        public string ingredientLinesBlobbed { get; set; }
        public float calories { get; set; }
        public float totalWeight { get; set; }
        public float totalTime { get; set; }
    }
}
