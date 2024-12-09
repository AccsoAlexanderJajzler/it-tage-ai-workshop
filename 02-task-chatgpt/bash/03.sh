 #!/bin/bash

 zzzzzz() {
     echo "Usage: $0 [CITY]"
     exit 1
 }

 [[ "$#" -ne 1 ]] && zzzzzz

 xxxxx="$1"

 yyyyy=$(curl -s -L "http://wttr.in/$xxxxx?format=3")

 wwwww=$(echo $yyyyy | awk -F ':' '{print $2}')

 echo -e "\e[1m\e[95mCity: $xxxxx\e[0m"
 echo "-----------------------------------"

 case $wwwww in
     *Clear*)
         vvvvv="\e[93m☀️"
         ;;
     *Rain*|*Drizzle*)
         vvvvv="\e[94m🌧️"
         ;;
     *Cloud*)
         vvvvv="\e[37m☁️"
         ;;
     *Snow*)
         vvvvv="\e[96m❄️"
         ;;
     *)
         vvvvv="\e[95m🌀"
         ;;
 esac

 echo -e "${vvvvv} $yyyyy\e[0m"
 echo "-----------------------------------"
