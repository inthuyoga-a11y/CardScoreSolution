# 🃏 Card Scoring Application

A **C# Card Game Score App** that calculates the total score of a hand of playing cards according to defined rules.  
Developed entirely using **Test Driven Development (TDD)** with **100% unit test coverage**.

---

## 📘 Overview

This application takes a **comma-separated list of playing cards** as input, validates them, and computes a **final score** based on each card’s value and suit.  

The scoring logic is implemented in **C#**, with a simple **console interface** for user interaction.  
All rules and edge cases are verified by automated **unit tests**.

---

## 🧮 Scoring Rules

| Card | Value | Suit | Multiplier |
|------|--------|------|-------------|
| 2–9 | Face Value | Clubs (C) | ×1 |
| T | 10 | Diamonds (D) | ×2 |
| J | 11 | Hearts (H) | ×3 |
| Q | 12 | Spades (S) | ×4 |
| K | 13 |  |  |
| A | 14 |  |  |
| JR (Joker) | – | – | Doubles total score |

### Example
`AS` = Ace (14) × Spade (4) = **56 points**  
`4D` = 4 × 2 = **8 points**  
Total = 64 points  
If a Joker (`JR`) appears → **Final Score = 64 × 2 = 128**

---

## 🧰 Features

✅ Calculates total score for valid hands  
✅ Accepts input as a comma-separated list (e.g., `AS,4C,JR`)  
✅ Detects and rejects duplicate cards  
✅ Allows up to **two Jokers**  
✅ Built using **C# and TDD** methodology  
✅ Achieves **100% unit test coverage**

---

## ⚙️ Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022 (v17.8 or later) or Visual Studio Code with C# extension

---

## 🚀 Running the Application

### 1️⃣ Build the project
```bash
dotnet build
