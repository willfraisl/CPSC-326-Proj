//https://tahahachana.github.io/XPlot/chart/google-geo-chart.html

#load "../../packages/FsLab/FsLab.fsx"

open FSharp.Data
open XPlot.GoogleCharts

type Income = CsvProvider<"../../data/State_median_income.csv">
type HPI = CsvProvider<"../../data/State_house_price_index.csv">

let options =
    Options(
        region = "US",
        resolution = "provinces",
        colorAxis = ColorAxis(colors = [|"red";"yellow";"green";|])
    )

let income = Income.Load("../../data/State_median_income.csv")
let hpi = HPI.Load("../../data/State_house_price_index.csv")

let year_income =
    [ for row in income.Rows do
        yield row.State, row.``2015``
    ]

let year_hpi =
    [ for row in hpi.Rows do
        yield row.State, row.``2015``
    ]

// Only plots one at a time right now
year_income
// year_hpi
|> Chart.Geo
|> Chart.WithLabels ["Median Income"]
|> Chart.WithOptions options

