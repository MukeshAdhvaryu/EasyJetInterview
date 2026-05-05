# **Knight's Tour (Knight’s Travel) Problem**

## Overview

This solution tackles the Knight’s Tour problem, where a knight must visit every square on a chessboard exactly once.

The goal is not just to produce a working solution, but to build something that is easy to understand, extend, and verify through testing from the outset.

---

## Approach

The design starts from the outside in, focusing first on what the system should be capable of before deciding how it achieves it.

At its core, the system is responsible for determining a valid tour from a given starting position. This responsibility is treated independently from the details of how moves are generated, how validity is enforced, or how the search is performed.

Tests are written first and used to shape the design. They describe expected behaviour rather than implementation, allowing the underlying approach to evolve without breaking intent.

The general workflow is:

* Begin with failing tests that reference behaviour and types that do not yet exist
* Introduce just enough structure to make the tests compile
* Incrementally implement behaviour until the tests pass

The tests focus on:

* ensuring moves follow the rules of a knight
* keeping positions within the bounds of the board
* preventing revisiting of squares
* confirming that a full tour can be completed

---

## Coding Style

A few guiding principles are followed throughout:

* Prefer early returns to keep control flow straightforward
* Avoid deep nesting where possible
* Use small, focused types to model domain concepts

The emphasis is on clarity over cleverness.

---

## Trade-offs

* A simple, predictable search approach is preferred over more complex optimisations
* The design keeps responsibilities loosely coupled so that different strategies or rules could be introduced later if needed
* No optimisation is pursued beyond what is required for correctness

If performance becomes a concern, a more efficient strategy (such as a heuristic-based approach like Warnsdorff’s rule) could be introduced without changing the overall behaviour expected by the system.

---

## Running the Solution

* A console application runs the tour
* A separate test project verifies behaviour

No external dependencies are required beyond standard tooling (tests may use something like NSubstitute if isolation becomes useful).

---

## Implementation Notes

The initial implementation uses a straightforward search strategy that explores possible paths and abandons those that cannot lead to a complete tour.

At a high level:

| Step | What happens                                                                  |
| ---- | ----------------------------------------------------------------------------- |
| 1    | Start from an initial square and treat it as visited                          |
| 2    | Check whether all squares have been visited                                   |
| 3    | Determine the possible next moves from the current position                   |
| 4    | Discard moves that fall outside the board or revisit a square                 |
| 5    | Attempt each remaining move in turn                                           |
| 5a   | Progress to the new position and continue the process                         |
| 5b   | If a complete tour is found, stop                                             |
| 5c   | If not, abandon that path and try the next option                             |
| 6    | If no options succeed, return to the previous position and continue searching |

This keeps the logic easy to follow while providing a solid baseline for future refinement.

---

## Future Improvements

If I were to take this further, I’d look at:

a heuristic-based solver (for example, Warnsdorff’s rule) to reduce the amount of backtracking.

The current interface-based design allows this to be added without changing existing tests or domain logic.

Beyond that, I would defer additional abstraction (such as runtime strategy selection or instrumentation) 
until there is a clear requirement.

---
