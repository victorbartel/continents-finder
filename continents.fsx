open System
/// This module contains very simple, greedy and naive implementation of continents/island finder
/// Time complexity of this algorithm is O(KM) where K is the count of rows and M is the count of columns
module Continents = 

    let matrix = [| 
                    [| 0; 0; 0; 0; 0; 0; 0; 0 |];
                    [| 0; 0; 0; 1; 1; 1; 1; 0 |];
                    [| 0; 0; 0; 0; 1; 1; 0; 0 |];
                    [| 0; 1; 1; 0; 1; 1; 0; 0 |];
                    [| 0; 1; 1; 0; 1; 1; 1; 1 |];
                    [| 0; 1; 1; 0; 0; 0; 0; 0 |];
                    [| 0; 1; 1; 0; 0; 0; 0; 0 |];
                    [| 0; 0; 0; 1; 0; 0; 1; 0 |];
                    [| 0; 0; 0; 0; 0; 0; 1; 0 |];
                    [| 0; 0; 0; 0; 0; 0; 1; 0 |];
                 |]

    type Segment = {landIndexes: int Set}
    type Cursor = {prevSegment: Segment; total: int}

    let ``more than zero`` = 0 |> (>=)
    let toSet: int seq -> int Set = ``more than zero`` |> Seq.filter >> set 
    let initSegment = {landIndexes = Set.empty}

    let tupleToSet (x, y, z) = [x; y; z] |> Set.ofList

    let fusionNeighbours (accumulator: int Set list) (candidate: int Set) =
        match accumulator with
        | [] -> [candidate]
        | head :: tail ->
            let intersect = candidate |> Set.intersect
            match (head |> intersect).Count with
            | 2 -> (head |> (Set.union candidate)) :: tail
            | _ -> candidate :: accumulator

    let foldLands (acc: Cursor) (a: int []) =
        let intersect = acc.prevSegment.landIndexes |> Set.intersect 
        let mapTuples = fst >> (fun x -> [x - 1; x ; x + 1] |> Set.ofList)
        let currentLandIndexTuples = 
            (a 
                |> Seq.mapi (fun i x -> (i, x))
                |> Seq.filter (fun x -> (x |> snd) <> 0))
        let continentIndexes = 
            currentLandIndexTuples 
            |> Seq.map mapTuples
            |> Seq.fold fusionNeighbours []
        
        let discovery = 
            continentIndexes
            |> Seq.filter (fun x -> (intersect x).Count = 0) 
            |> Seq.length

        let landIndexes = currentLandIndexTuples |> Seq.map fst |> Set.ofSeq 

        { total = discovery + acc.total; prevSegment = {landIndexes = landIndexes } }

    let countContinents x =
        (x |>
            Array.fold (foldLands) {prevSegment = initSegment; total = 0}).total

    let main args =
        matrix
        |> countContinents 
        |> (printf "%d continent(s) was(were) discovered\r\n")
        0

Continents.main []
