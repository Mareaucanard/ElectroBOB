FROM debian:12-slim as base
ENV DEBIAN_FRONTEND=noninteractive
WORKDIR /app/

RUN apt-get update                                \
    && apt-get install -y                         \
    curl                                      \
    npm                                       \
    nodejs
RUN rm -rf /var/lib/apt/lists/*

COPY ./electro-bob /electro-bob
WORKDIR /electro-bob
RUN npm install -g npm@10.2.5
RUN npm install nuxt
RUN npm install --global yarn
RUN yarn install
CMD ["yarn", "run", "dev"]

