#!/bin/bash

echo "$(ls Assets)"
echo "$(ls Assets/Conda)"
echo "$(ls Assets/Conda/lib)"


for fname in Assets/Conda/*.txt; do
echo $fname
echo conda list 
# Don't forget the "" around the second part, else newlines won't be printed
echo "$(<$fname)"

done
