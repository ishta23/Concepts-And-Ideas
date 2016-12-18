//F# library to analyse Chicago crime data
//Ishta Bhagat 
//U. of Illinois, Chicago
//CS341, Spring 2016
//HW6

module FSAnalysis

#light

open System
open FSharp.Charting
open FSharp.Charting.ChartTypes
open System.Drawing
open System.Windows.Forms

//
// Parse one line of CSV data:
//
//   Date,IUCR,Arrest,Domestic,Beat,District,Ward,Community,Year
//   09/03/2015 11:57:00 PM,0820,true,false,0835,008,18,66,2015
//   ...
//
// Returns back a tuple with most of the information:
//
//   (date, iucr, arrested, domestic, community, year)
//
// as string*string*bool*bool*int*int.
//
let private ParseOneCrime (line : string) = 
  let elements = line.Split(',')
  let date = elements.[0]
  let iucr = elements.[1]
  let arrested = Convert.ToBoolean(elements.[2])
  let domestic = Convert.ToBoolean(elements.[3])
  let community = Convert.ToInt32(elements.[elements.Length - 2])
  let year = Convert.ToInt32(elements.[elements.Length - 1])
  (date, iucr, arrested, domestic, community, year)

let private ParseIucr (line: string) = 
  let elements = line.Split(',')
  let iucr = elements.[0]
  let primary = elements.[1]
  let secondary = elements.[2]
  (iucr, primary, secondary)


let private ParseArea (line: string) = 
  let elements = line.Split(',')
  let id = elements.[0]
  let name = elements.[1]
  (id, name)
// 
// Parse file of crime data, where the format of each line 
// is discussed above; returns back a list of tuples of the
// form shown above.
//
// NOTE: the "|>" means pipe the data from one function to
// the next.  The code below is equivalent to letting a var
// hold the value and then using that var in the next line:
//
//  let LINES  = System.IO.File.ReadLines(filename)
//  let DATA   = Seq.skip 1 LINES
//  let CRIMES = Seq.map ParseOneCrime DATA
//  Seq.toList CRIMES
//
let private ParseCrimeData filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseOneCrime
  |> Seq.toList

//
let private ParseIucrData filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseIucr
  |> Seq.toList

let private ParseAreaData filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseArea
  |> Seq.toList
//
// Given a list of crime tuples, returns a count of how many 
// crimes were reported for the given year:
//
let private CrimesThisYear crimes crimeyear = 
  let crimes2 = List.filter (fun (date, iucr, arrested, domestic, community, year) -> year = crimeyear) crimes
  let numCrimes = List.length crimes2
  numCrimes

//
// CrimesByYear:
//
// Given a CSV file of crime data, analyzes # of crimes by year, 
// returning a chart that can be displayed in a Windows desktop
// app:
//
let CrimesByYear(filename) = 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesByYear: %A" filename
  //
  let crimes = ParseCrimeData filename
  //
  let (_, _, _, _, _, minYear) = List.minBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  //
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts
  //
  // debugging: see Visual Studio's Output window (may need to scroll up?)
  //
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear
  //
  // plot:
  //
  let myChart = 
    Chart.Combine([
                  Chart.Line(countsByYear, Name="Total # of Crimes")
    ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl
let private ArrestsThisYear crimes crimeyear = 
  let crimes2 = List.filter (fun (_, _, arrested, _ , _ , year) -> year = crimeyear && arrested ) crimes
  let numCrimes = List.length crimes2
  numCrimes

let ArrestsByYear(filename) = 
    //
    // debugging:  print filename, which appears in Visual Studio's Output window
    //
    printfn "Calling CrimeVsArrests: %A" filename
    //
    let crimes = ParseCrimeData filename
    //
    let (_, _, _, _, _, minYear) = List.minBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
    let (_, _, _, _, _, maxYear) = List.maxBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
    //

    
    //
    let range  = [minYear .. maxYear]
    let counts = List.map (fun year -> CrimesThisYear crimes year) range
    let arrests = List.map (fun year -> ArrestsThisYear crimes year) range
    let arrestsByYear = List.map2 (fun year arrests -> (year, arrests)) range arrests
    let countsByYear = List.map2 (fun year count -> (year, count)) range counts
    //
    // debugging: see Visual Studio's Output window (may need to scroll up?)
    //
    printfn "Counts: %A" counts
    printfn "Counts by Year: %A" arrestsByYear
    //
    // plot:
    //
    let myChart = 
      Chart.Combine([
                     Chart.Line(countsByYear, Name="Total # of Crimes")
                     Chart.Line(arrestsByYear, Name="# of Arrests")
      ])
    let myChart2 = 
      myChart.WithTitle(filename).WithLegend();
    let myChartControl = 
      new ChartControl(myChart2, Dock=DockStyle.Fill)
    //
    // return back the chart for display:
    //
    myChartControl
let private ByCrimesThisYear crimes crimeyear input = 
  let crimes2 = List.filter (fun (_, iucr, _, _ , _ , year) -> year = crimeyear && iucr = input) crimes
  let numCrimes = List.length crimes2
  numCrimes
let private findName input = 
   let iucrList = ParseIucrData "IUCR-codes.csv"
   if iucrList = [] then
    "UNKNOWN Crime Code"
   else
    let found = List.filter(fun (iucr, primary, secondary)-> iucr = input ) iucrList

    //let first = (fun (x,y,z) -> y) found.Head
    let F = fun (x,y,z) -> y
    let F2 = fun(x, y,z) -> z
    F found.Head + ": "+ F2 found.Head
    //let sec = (fun (x,y,z)-> z) found.Head
    //let ret = first  +": " + sec 
    //ret

let CountsByCrime(filename, input) = 
    //
    // debugging:  print filename, which appears in Visual Studio's Output window
    //
    printfn "Calling CrimeByYear: %A" filename 
    //
    let crimes = ParseCrimeData filename
    //
    let (_, _, _, _, _, minYear) = List.minBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
    let (_, _, _, _, _, maxYear) = List.maxBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
    //

    
    //
    let range  = [minYear .. maxYear]
    let counts = List.map (fun year -> CrimesThisYear crimes year) range

    let specificCrime = List.map(fun year -> ByCrimesThisYear crimes year input) range
    let countsByYear = List.map2 (fun year count -> (year, count)) range counts

    let countsByCrime = List.map2 (fun year count -> (year, count)) range specificCrime
    
    
    //
    // debugging: see Visual Studio's Output window (may need to scroll up?)
    //
    printfn "Counts: %A" counts
    printfn "Counts by Crime: %A" countsByCrime
    //
    // debugging: see Visual Studio's Output window (may need to scroll up?)
    //
    printfn "Counts: %A" specificCrime
    printfn "Counts by Crime: %A" countsByCrime
    //
    let test = findName input
    //
    // plot:
    //
    let myChart = 
      Chart.Combine([
                     Chart.Line(countsByYear, Name="Total # of Crimes")
                     Chart.Line(countsByCrime, Name=test)
      ])
    let myChart2 = 
      myChart.WithTitle(filename).WithLegend();
    let myChartControl = 
      new ChartControl(myChart2, Dock=DockStyle.Fill)
    //
    // return back the chart for display:
    //
    myChartControl




let private ByAreaThisYear crimes crimeyear input = 
  let crimes2 = List.filter (fun (_, _, _, _ , community , year) -> year = crimeyear && community = input) crimes
  let numCrimes = List.length crimes2
  numCrimes

let private findName2 code = 
   let areaList = ParseAreaData "Areas.csv"
   if  areaList = [] then
    "UNKNOWN Crime Code"
   else
    let found = List.filter(fun (num, name)-> num = code ) areaList

    //let first = (fun (x,y,z) -> y) found.Head
    let F = fun (x,y) -> x
    let F2 = fun(x, y) -> y
    F found.Head + ": "+ F2 found.Head
    

let CountsByArea(filename, input) = 
    //
    // debugging:  print filename, which appears in Visual Studio's Output window
    //
    printfn "Calling CrimeByYear: %A" filename 
    //
    let crimes = ParseCrimeData filename
    //
    let (_, _, _, _, _, minYear) = List.minBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
    let (_, _, _, _, _, maxYear) = List.maxBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
    //

    
    //
    let range  = [minYear .. maxYear]
    let counts = List.map (fun year -> CrimesThisYear crimes year) range

    let areaCrime = List.map(fun year -> ByAreaThisYear crimes year input) range
    let countsByYear = List.map2 (fun year count -> (year, count)) range counts

    let countsByArea = List.map2 (fun year count -> (year, count)) range areaCrime
    
    
    //
    // debugging: see Visual Studio's Output window (may need to scroll up?)
    //
    printfn "Counts: %A" counts
    printfn "Counts by Crime: %A" countsByYear
    //
    // debugging: see Visual Studio's Output window (may need to scroll up?)
    //
    printfn "Counts: %A"areaCrime
    printfn "Counts by Crime: %A" countsByArea
    //
    let int2String x = sprintf "%i" x
    let input2 = int2String input 
    let test = findName2 input2
    //
    // plot:
    //
    let myChart = 
      Chart.Combine([
                     Chart.Line(countsByYear, Name="Total # of Crimes")
                     Chart.Line(countsByArea, Name=test)
      ])
    let myChart2 = 
      myChart.WithTitle(filename).WithLegend();
    let myChartControl = 
      new ChartControl(myChart2, Dock=DockStyle.Fill)
    //
    // return back the chart for display:
    //
    myChartControl


    //returns the num of crimes with specific community address
let private CrimesTotal crimes communityNum= 
  let crimes2 = List.filter (fun (date, iucr, arrested, domestic, community, year) -> community = communityNum) crimes
  let numCrimes = List.length crimes2
  numCrimes

let overallCrimes(filename) = 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesPerArea: %A" filename
  //
  let crimes = ParseCrimeData filename
  //
  let (_, _, _, _, minCom, _) = List.minBy (fun (date, iucr, arrested, domestic, community, year) -> community) crimes
  let (_, _, _, _,maxCom, _) = List.maxBy (fun (date, iucr, arrested, domestic, community, year) -> community) crimes
  //
  let range  = [(minCom+1) .. maxCom]
  let counts = List.map (fun communityNum -> CrimesTotal crimes communityNum) range
  let overallCount = List.map2 (fun community count -> (community, count)) range counts
  //
  // debugging: see Visual Studio's Output window (may need to scroll up?)
  //
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" overallCount
  //
  // plot:
  //
  let myChart = 
    Chart.Combine([
                  Chart.Line(overallCount, Name="Total Crimes by Chicago Area")
    ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl