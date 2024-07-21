#!/bin/bash

echo "$(ls Assets)"
echo "$(ls Assets/Conda)"
echo "$(ls Assets/Conda/lib)"


select fname in Assets/Conda/*.txt;
do
# Don't forget the "" around the second part, else newlines won't be printed
  printf "%s" "$(<$fname)"
  break
done
