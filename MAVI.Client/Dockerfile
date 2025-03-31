FROM node:18 AS build
WORKDIR /app

COPY MAVI.Client/package*.json ./
RUN npm install

COPY MAVI.Client ./ 
RUN npm run build --configuration=production

FROM nginx:1.21 AS serve
COPY --from=build /app/dist/mavi.client/browser /usr/share/nginx/html
COPY MAVI.Client/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]