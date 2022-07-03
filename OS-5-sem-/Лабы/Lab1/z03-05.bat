@echo off
echo ~~~Parameters: %1 %2 %3
echo ~~~Parameter1: %1
echo ~~~Parameter2: %2
echo ~~~Parameter3: %3
set /a result = %1 %3 %2
echo ~~~Result = %result%