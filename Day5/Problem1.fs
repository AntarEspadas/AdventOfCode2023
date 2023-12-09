module Day5.Problem1

open System

type Mapping = {
    targetStart: int64
    sourceStart: int64
    length: int64
}

type Almanac = {
    seeds: int64 seq
    mappings: Mapping seq seq
}

let getMapping [| targetStart; sourceStart; length |] =
    {
        targetStart = targetStart
        sourceStart = sourceStart
        length = length 
    }

let parseSeeds (seedsStr: string) =
    seedsStr.Split(' ')
    |> Seq.tail
    |> Seq.map Int64.Parse
    
let parseMappings (lines: string array) =
    lines
    |> Seq.tail
    |> Seq.map (fun x -> x.Split(" "))
    |> Seq.map (Array.map Int64.Parse)
    |> Seq.map getMapping

let parse (input: string) =
    let sections =
        input.Split("\n\n")
        |> Seq.map (fun x -> x.Trim())
        |> Seq.map (fun x -> x.Split("\n"))
    let seeds =
                sections
                |> Seq.head
                |> Seq.head
                |> parseSeeds
    let mappings =
                sections
                |> Seq.tail
                |> Seq.map parseMappings
    {
        seeds = seeds
        mappings = mappings 
    }
    
let isInRange seed mapping =
    let sourceEnd = mapping.sourceStart + mapping.length
    mapping.sourceStart <= seed && seed <= sourceEnd
    
let getTarget seed mapping =
    if not (isInRange seed mapping) then
        None
    else
        Some (seed - mapping.sourceStart + mapping.targetStart)
        
let resolve seed mappings =
    mappings
    |> Seq.choose (getTarget seed)
    |> Seq.tryHead
    |> Option.defaultValue seed
    
let mapSeed (mappings: Mapping seq seq) seed =
    mappings
    |> Seq.fold resolve seed
    
let solve (input: string) =
    let almanac = parse input
    almanac.seeds
    |> Seq.map (mapSeed almanac.mappings)
    |> Seq.min