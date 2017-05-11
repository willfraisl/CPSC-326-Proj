(*
    CPSC 326 Final Project
    By Will Fraisl, Blake Erickson

    Our project generates a heatmap of US states that shows a score for each 
    state. The score is generated from a mix of the housing price index and 
    median household income for that state. States with a higher score show 
    plases that are "easier" to live. Meaning the median household income is 
    higher compared to the housing price index. Also to begin the program asks 
    for user input in the console to choose a year to display.
*)

//Load in F# Labs
#load "../../packages/FsLab/FsLab.fsx"

//Open required libraries
open System
open Deedle
open FSharp.Data
open XPlot.GoogleCharts
open XPlot.GoogleCharts.Deedle

//Function to get year from user
let getYear =
    Console.Write("Input year: ")
    Console.ReadLine()

//Read income CSV file
let income = Frame.ReadCsv("State_median_income.csv") |> Frame.indexRowsString("State")

//Read hpi CSV file
let hpi = Frame.ReadCsv("State_house_price_index.csv") |> Frame.indexRowsString("State")

//Calculate state score
let ratio = hpi.Zip(income, fun a b -> float(a)/float(b) * 1000.0)

//Create google chart
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
