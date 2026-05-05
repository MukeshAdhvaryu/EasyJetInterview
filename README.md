# **Knights Travel (Knight’s Tour) problem - Development Notes**

## Overview

This is a solution to the Knight’s Tour problem, where a knight must visit every square on a chessboard exactly once.

The focus here isn't just getting a working solution, but putting together something that’s easy to read, easy to extend, and testable from the start.

---

## Approach

I would start from the outside in by defining what the system should do before worrying about how it does it.

The core abstraction is `an interface to find an appropriate tour route`, which represents the ability to find a valid tour from a starting position. Everything else hangs off that.

The initial implementation uses a simple backtracking approach. It’s not the most efficient possible solution, but it’s predictable and easy to follow, which felt like the right trade-off for a baseline.

---