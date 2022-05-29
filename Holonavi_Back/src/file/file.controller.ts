import { Body, Controller, Get, HttpStatus, Param, Post, Patch, Query, Res, UploadedFile, UploadedFiles, UseInterceptors } from '@nestjs/common';
import { FileInterceptor } from '@nestjs/platform-express';
import { join } from 'path';
import { Observable, of } from 'rxjs';
import { UploadFileDto } from './dto/upload-file.dto';
import { FileService } from './file.service';

import { UploadOptions } from './option/file.options';

var downname = ''
@Controller('file')
export class FileController {
    constructor(private readonly fileService: FileService) {}

    @Get('list')
    async fileList() {
        const Flist = await this.fileService.findall();

        return Flist;
    }

    @Get(':index')
    findOne(@Param('index') index: number): Promise<any> {
        return this.fileService.findOne(index);
    }

    @Post('upload') 
    @UseInterceptors(FileInterceptor('file', UploadOptions))
    uploadFile(@UploadedFile() files: Express.Multer.File) {
        const uploadedFiles : string[] = this.fileService.uploadFile(files);

        return {
            status: 200,
            message: '파일 업로드 완료',
            data: { files: uploadedFiles }
        }
    }

    @Post('imgupload/:file')
    @UseInterceptors(FileInterceptor('file', UploadOptions))
    uploadimg(@Param("file") saveName: string ,@UploadedFile() files: Express.Multer.File) {
        return this.fileService.uploadImg(saveName, files);
    }

    @Get('set/:filename')
    setFile(@Param('filename') filename : string): string {
        downname = filename;
        console.log("다운로드 파일을 " + downname + "으로 설정하였습니다.");
        return downname;
    }

    @Get('ee')
    fileDownload(@Res() res): string {
        console.log(downname);
        return res.download("maps/" + downname);
    }

    @Get('downloads/:name')
    downloadFilename(@Res() res, @Param('name') name: string): string {
        console.log(name);
        console.log(downname);
        return res.download("maps/" + downname);
    } 

    @Get('view/:imgname')
    ViewImg(@Param('imgname') imgname, @Res() res): Observable<Object> {
        return of(res.sendFile(join(process.cwd(), 'maps/' + imgname)));
    }
}

