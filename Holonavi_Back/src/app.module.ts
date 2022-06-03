import { Module } from '@nestjs/common';
import { APP_FILTER } from '@nestjs/core';
import { MulterModule } from '@nestjs/platform-express';
import { TypeOrmModule } from '@nestjs/typeorm';
import CatchException from './exception/CatchException';
import { FileModule } from './file/file.module';

@Module({
  imports: [
    TypeOrmModule.forRoot(),
    AppModule,
    FileModule,
    MulterModule.register({
      dest: './maps',
    }),
  ],
  controllers: [],
  providers: [
    {
      provide: APP_FILTER,
      useClass: CatchException,
    },
  ],
})
export class AppModule {}
