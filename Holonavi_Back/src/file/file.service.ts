import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { getConnection, Repository } from 'typeorm';
import { UploadFileDto } from './dto/upload-file.dto';
import { uploadFileURL } from './option/file.options';
import { File } from './entities/file.entity';

@Injectable()
export class FileService {
  constructor(
    @InjectRepository(File)
    private readonly fileRepository: Repository<File>,
  ) {
    this.fileRepository = fileRepository;
  }

  public uploadFile(file: Express.Multer.File): string[] {
    const Files: string[] = [];
    console.log('파일:', file);
    Files.push(uploadFileURL(file));
    this.uploadFileDB({
      Original: file.originalname,
      Save: file.filename,
      OriImg: '',
      SaveImg: '',
    });
    return Files;
  }

  async uploadImg(saveName: string, File: Express.Multer.File): Promise<any> {
    console.log(File);
    await getConnection()
      .createQueryBuilder()
      .update('file')
      .set({ SaveImg: File.filename, OriImg: File.originalname })
      .where('Save = :saveName', { saveName })
      .execute();
  }

  async uploadFileDB(uploadFiledto: UploadFileDto): Promise<any> {
    const { Original, Save, OriImg, SaveImg } = uploadFiledto;
    const newFile = new File();

    newFile.Original = Original;
    newFile.Save = Save;
    newFile.OriImg = OriImg;
    newFile.SaveImg = SaveImg;

    await this.fileRepository.save(newFile);
    return ``;
  }

  findall(): Promise<File[]> {
    return this.fileRepository.find({
      select: ['Original', 'Save', 'OriImg', 'SaveImg'],
    });
  }

  findOne(index: number): Promise<any> {
    var save = this.fileRepository.findOne(
      { FileNo: index },
      {
        select: ['Save'],
      },
    );
    return save;
  }
}
