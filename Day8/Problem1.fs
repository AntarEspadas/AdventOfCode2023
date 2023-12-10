module Day8.Problem1

let parseLine (line: string) =
    let [| key; value |] = line.Replace(" ", "").Split('=')
    let [| left; right |] = value.Replace("(", "").Replace(")", "").Split(',')
    key, (left, right)
    
let parse (lines: string seq) =
    Seq.head lines,
    lines
    |> Seq.skip 2
    |> Seq.map parseLine
    |> Map.ofSeq
    
let advance (nodes: Map<string, string * string>) (_key, (leftNode, rightNode)) c =
    if c = 'L' then
        leftNode, nodes[leftNode]
    else
        rightNode, nodes[rightNode]
        
let walk directions nodes isEnd initialNode=
     Seq.initInfinite (fun _ -> directions)
     |> Seq.concat
     |> Seq.scan (advance nodes) initialNode
     |> Seq.takeWhile (not << isEnd)
     
let solve lines =
    let directions, nodes = parse lines
    let initialNode =
        nodes
        |> Seq.map (fun x -> x.Key, x.Value)
        |> Seq.find (fst >> (=) "AAA")

    walk directions nodes (fst >> (=) "ZZZ") initialNode 
    |> Seq.length