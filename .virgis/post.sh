#!/bin/bash

echo "$(ls ~/local/miniconda3)"
echo "$(ls ~/local/miniconda3/bin)"

echo "$(ls Assets)"
echo "$(ls Assets/Conda)"


select fname in Assets/Conda/*.txt;
do
# Don't forget the "" around the second part, else newlines won't be printed
  printf "%s" "$(<$fname)"
  break
done
