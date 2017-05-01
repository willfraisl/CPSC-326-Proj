//https://tahahachana.github.io/XPlot/chart/google-geo-chart.html

#load "../../packages/FsLab/FsLab.fsx"

open FSharp.Data
open XPlot.GoogleCharts

type Income = CsvProvider<"../../data/State_median_income.csv">

let options =
    Options(
        region = "US",
        resolution = "provinces"
    )

let income = Income.Load("../../data/State_median_income.csv")

let buildList =
    [ for row in income.Rows do
        yield row.State, row.``2015``
    ]

let fakeData =
  [ "Alabama", 1, 2;
    "Alaska", 1, 2;
    "Arizona", 1, 2;
    "Arkansas", 1, 2;
    "California", 1, 2;
    "Colorado", 1, 2;
    "Connecticut", 1, 2;
    "Delaware", 1, 2;
    "Florida", 1, 2;
    "Georgia", 1, 2;
    "Hawaii", 1, 2;
    "Idaho", 1, 2;
    "Illinois", 1, 2;
    "Indiana", 1, 2;
    "Iowa", 1, 2;
    "Kansas", 1, 2;
    "Kentucky", 1, 2;
    "Louisiana", 1, 2;
    "Maine", 1, 2;
    "Maryland", 1, 2;
    "Massachusetts", 1, 2;
    "Michigan", 1, 2;
    "Minnesota", 1, 2;
    "Mississippi", 1, 2;
    "Missouri", 1, 2;
    "Montana", 1, 2;
    "Nebraska", 1, 2;
    "Nevada", 1, 2;
    "New Hampshire", 1, 2;
    "New Jersey", 1, 2;
    "New Mexico", 1, 2;
    "New York", 1, 2;
    "North Carolina", 1, 2;
    "North Dakota", 1, 2;
    "Ohio", 1, 2;
    "Oklahoma", 1, 2;
    "Oregon", 1, 2;
    "Pennsylvania", 1, 2;
    "Rhode Island", 1, 2;
    "South Carolina", 1, 2;
    "South Dakota", 1, 2;
    "Tennessee", 1, 2;
    "Texas", 1, 2;
    "Utah", 1, 2;
    "Vermont", 1, 2;
    "Virginia", 1, 2;
    "Washington", 1, 2;
    "West Virginia", 1, 2;
    "Wisconsin", 1, 2;
    "Wyoming", 1, 2; ]


buildList

|> Chart.Geo
|> Chart.WithLabels ["Median Income"]
|> Chart.WithOptions options
