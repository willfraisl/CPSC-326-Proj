//https://tahahachana.github.io/XPlot/chart/google-geo-chart.html

#load "../../packages/FsLab/FsLab.fsx"

open XPlot.GoogleCharts

let pop =
  [ "Germany", 200; "United States", 300
    "Brazil", 400;  "Canada", 500
    "France", 600;  "RU", 700 ]
pop
|> Chart.Geo
|> Chart.WithLabel "Popularity"