//https://tahahachana.github.io/XPlot/chart/google-geo-chart.html

#load "../../packages/FsLab/FsLab.fsx"

open XPlot.GoogleCharts

let options = 
    Options(
        region = "US",
        resolution = "provinces"
    )
let pop =
  [ "US-CA", 200; "US-WA", 300
    "US-NV", 400;  "US-NY", 500
    "US-MT", 600;  "US-NJ", 700 ]
pop
|> Chart.Geo
|> Chart.WithOptions options

