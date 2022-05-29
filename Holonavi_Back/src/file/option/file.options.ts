import { HttpException, HttpStatus } from "@nestjs/common";
import { existsSync, mkdirSync } from "fs";
import { diskStorage } from "multer";
import HttpError from "src/exception/HttpError";
import uuidRandom from "./uuidRandom";

export const UploadOptions = {
    fileFilter: (request, file, callback) => {
        /*if (file.mimetype.match(/\/(json)$/)) {
            console.log('option: ', file);
            callback(null, true);
        } else {
            callback(new HttpError(400, '지원하지 않는 이미지 형식입니다.'), false);
        }*/
        console.log('option: ', file);
        callback(null, true);
    },
    
    storage: diskStorage({
        destination: (request, file, callback) => {
            const uploadPath = 'maps';
            if(!existsSync(uploadPath)) {
                mkdirSync(uploadPath);
            }
            callback(null, uploadPath);
        },
        filename: (request, file, callback) => {
                callback(null, uuidRandom(file));
            
        }
    })
}

export const uploadFileURL = (file : Express.Multer.File): string => {
    console.log(file);
    return `http://loaclhost:3000/maps/${file.filename}`;
}

export const uploadFileName = (file: Express.Multer.File): string => {
    return file.filename;
}