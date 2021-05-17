# pull the official base image  
FROM node:13.12.0-alpine as build

# set your working directory  
WORKDIR /

# install application dependencies  
COPY package.json ./  
COPY package-lock.json ./  
RUN npm install --silent  

# add app  
COPY . ./
RUN npm run build


FROM nginx:1.17.1-alpine

COPY ./nginx/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build ./build /usr/share/nginx/html
