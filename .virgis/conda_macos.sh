echo starting conda install

echo "$(ls ~/local/miniconda3)"
echo "$(ls ~/local/miniconda3/bin)"

curl https://repo.anaconda.com/miniconda/Miniconda3-latest-MacOSX-x86_64.sh -o conda.sh
bash conda.sh -b -p ~/local/miniconda3
echo completed conda install