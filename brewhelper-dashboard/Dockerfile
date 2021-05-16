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

COPY --from=build ./build /usr/share/nginx/html

# FROM node:13.12.0-alpine as final

# COPY --from=build ./build ./
# RUN npm install -g serve
# EXPOSE 5000

# # will start app  
# CMD ["serve", "-s", "build"] 