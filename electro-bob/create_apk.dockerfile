FROM node:21-alpine

WORKDIR /build-app

# Install bash and java
RUN apk update
RUN apk add bash openjdk17
ENV JAVA_HOME=/usr/lib/jvm/java-17-openjdk
ENV PATH="$PATH:$JAVA_HOME/bin"
RUN mkdir /android-sdk
RUN wget https://dl.google.com/android/repository/commandlinetools-linux-10406996_latest.zip && unzip *.zip -d /android-sdk && rm *.zip
ENV ANDROID_HOME="/android-sdk"
ENV PATH="$PATH:$ANDROID_HOME/cmdline-tools/bin"

# Install platform-tools
RUN yes | sdkmanager "platforms;android-32" "system-images;android-32;default;x86_64" --sdk_root="/android-sdk"
ENV PATH="$PATH:$ANDROID_HOME/platform-tools"


RUN npm update -g
RUN apk add gcompat

COPY . /build-app/

RUN yarn
RUN bash build-app.sh

RUN cp ./electroBOB.apk /var/mobile-app
