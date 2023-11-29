set -e

npx react-native build-android --mode=release
cp android/app/build/outputs/apk/release/app-release.apk electroBOB.apk

