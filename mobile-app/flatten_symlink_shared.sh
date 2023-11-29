function replace_link {
    dir=$1
    realtarget=$(readlink "$1")

    rm $dir
    cp -r $realtarget $dir
}

replace_link shared
