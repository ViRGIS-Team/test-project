#!/bin/bash

echo "$(ls Assets)"
echo "$(ls Assets/Conda)"
echo "$(ls Assets/Conda/lib)"


for fname in Assets/Conda/*.txt; do
echo $fname
# Don't forget the "" around the second part, else newlines won't be printed
echo "$(<Assets/Conda/$fname)"

done
