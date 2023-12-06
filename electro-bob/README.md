
# Preamble
This is the github of the ElectroBOB project.\
It was made by the Volume team, consisting of Adélaïde CHANTEUX, Ange Mouqet, Matthieu FRAIZ, Raymond VIERGE et Thibault MIR\
It is an EPITECH third year project, AREA.

The backend is made using .NET/C#

Both the website and mobile app are made using Nuxt 3
# Quick deployment
run `docker-compose` in the root of the project

By default, it will generate an apk, run the web client on the 8001 port and run the server on the 8081 port \
Config can be changed in the .env file

# Clients

Make sure to install the dependencies:
```bash
yarn install
```

# Website
## Development Server

Start the development server on `http://localhost:3000`:

```bash
yarn dev
```


## Production Server
Build the application for production:

```bash
yarn build
```

Locally preview production build:

```bash
yarn preview
```
Check out the [deployment documentation](https://nuxt.com/docs/getting-started/deployment) for more information.

# Mobile app
## Sync
```bash
npx nuxi generate # Create a web build
npx cap sync # Update capacitor project directories
```
## Development
Afterwards, you can may `npx cap open android` or `npx cap open ios` to open android studio or xcode respectively

`npx cap run android` or `npx cap run ios` to run the app

## Build
To generate an apk, either run the build-app.sh script or use the gradlew file in the android folder
