//https://tahahachana.github.io/XPlot/chart/google-geo-chart.html

#load "../../packages/FsLab/FsLab.fsx"

open System
open Deedle
open FSharp.Data
open XPlot.GoogleCharts
open XPlot.GoogleCharts.Deedle

let getYear =
    Console.Write("Input year: ")
    Console.ReadLine()


let income = Frame.ReadCsv("State_median_income.csv") |> Frame.indexRowsString("State")


let hpi = Frame.ReadCsv("State_house_price_index.csv") |> Frame.indexRowsString("State")


let ratio = hpi.Zip(income, fun a b -> float(a)/float(b) * 1000.0)

let chart =
    let options =
        Options(
            title = "Income vs HPI",
            region = "US",
            resolution = "provinces",
            colorAxis = ColorAxis(colors = [|"red";"yellow";"green";|])
        )
    ratio.GetColumn(getYear)
    |> Chart.Geo
    |> Chart.WithLabels ["Score"]
    |> Chart.WithOptions options
    |> Chart.Show
