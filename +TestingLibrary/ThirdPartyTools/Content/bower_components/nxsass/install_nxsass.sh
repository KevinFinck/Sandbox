#!/bin/bash
# nxsass setup script

clear

echo "        __      __                     ";
echo "        \ \    / /                     ";
echo "   _ __  | |  | | ___   __ _  ___  ___ ";
echo "  | '_ \  \ \/ / / __| / _\` |/ __|/ __|";
echo "  | | | | / /\ \ \__ \| (_| |\__ \\\\__ \\";
echo "  |_| |_|| |  | ||___/ \__,_||___/|___/";
echo "        /_/    \\_\\                     ";
echo "                                       ";
echo "                                ";
echo "              Quick Setup           ";
echo "                                ";
echo "                                ";
echo "        -Andrew Colclough: @wtc    ";
echo "        -Lauren Kodai: @The_Lela    ";
echo "                                ";
echo "                                ";
echo "                              ";

read -p  "  Welcome! Ready to setup nxsass [y]? " ready
if [[ "$ready" = "Y" ]] || [[ "$ready" = "y" ]]
  then
  mkdir ../../css
  # Move and rename source-template
  cp -Rv source-template ../../css/source
  # Copy Gulp
  cp -Rv gulp ../../gulp
  cp -v gulpfile.js ../../gulpfile.js
  # copy NPM dependency list
  cp -v package.json ../../package.json
  cp -v bower.template ../../bower.json
  # copy demo page...
  cp -v index.html ../../index.html
  cd ../../

  npm install

  echo "                                                                                            ";
  echo "      __      __                     ";
  echo "      \ \    / /                     ";
  echo " _ __  | |  | | ___   __ _  ___  ___ ";
  echo "| '_ \  \ \/ / / __| / _\` |/ __|/ __|";
  echo "| | | | / /\ \ \__ \| (_| |\__ \\\\__ \\";
  echo "|_| |_|| |  | ||___/ \__,_||___/|___/";
  echo "      /_/    \\_\\                     ";
  echo "                                     ";
  echo "                              ";
  echo "                                                                                            ";
  echo " --------------------------------------------------------------------------------------------";
  echo "|                                                                                            | ";
  echo "|   Well, that was easy. Go up two directories, run 'gulp', and visit http://localhost:1337  |";
  echo "|                                                                                            |";
  echo " -------------------------------------------------------------------------------------------- ";
  echo "                                                                                            ";

  else
    echo "                                                      ";
    echo "  Ok. No worries. Meet me back here when you are ready! "
    echo "                                                      ";

fi