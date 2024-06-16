# Zagoot: Two Player Counter-Based Game

## Introduction
Zagoot is a two-player strategy game where players take turns attempting to seize each others counters. It is a zero-sum game with perfect information, inspired by the game of checkers.

## Rules
The aim of the game is to seize all of your opponent’s counters, leaving only your own on the board. Each turn, players can move one counter, and each counter can only move one space at a time. All counters can move forwards or backwards; however, square counters can only move horizontally or vertically whilst round counters can only move diagonally. 
To seize a counter, move your counter to a space that is currently occupied by your opponent, their counter will then be removed from the board. Only 1 counter can be seized each turn. Additionally, any counter can seize an opponent’s counter, regardless of shape.

## Algorithm
1.	The user selects a counter and the space to move the counter to.
2.	The AI opponent implements a minimax algorithm with a depth of 2 to determine which counter to move and where. It uses has a static evaluation function that assesses the positioning of the counters on the gameboard. It then assigns a value representing the likelihood of winning from the current state of play. A higher value indicates a greater chance of winning. Potential seizing opoportunities increase the value while the risk of being seized decreases it.
3.	The AI opponent chooses the play with the greatest value and the corresponding counter is moved.
4.	The players continue to take it in turns to move counters until one player looses all of their counters. 
5.	The game ends and a winner is declared.

## Languages
C#

## Output
<img src="https://github.com/SamanthaMT/Zagoot-Two-Player-Counter-Game/blob/master/Zagoot%20Demonstration%20Short.gif" width=728px height=400px/>
