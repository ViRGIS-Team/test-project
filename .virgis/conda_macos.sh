echo starting conda install
curl https://repo.anaconda.com/miniconda/Miniconda3-latest-MacOSX-x86_64.sh -o conda.sh
bash conda.sh -b -p ~/local/miniconda3
echo 'export PATH=~/local/miniconda:$PATH' >>~/.bash_profile
echo completed conda install