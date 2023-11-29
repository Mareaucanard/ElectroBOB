I=0
for word in $(grep "versionName" android/app/build.gradle);
do
    let "I=I+1"
    if [ $I -eq 2 ];
    then
        word2=${word#'"'};
        word2=${word2%'"'};
        echo $word2
    fi
done
