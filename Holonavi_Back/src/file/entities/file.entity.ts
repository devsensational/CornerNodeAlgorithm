import {
  Entity,
  Column,
  Unique,
  CreateDateColumn,
  UpdateDateColumn,
  DeleteDateColumn,
  PrimaryGeneratedColumn,
} from 'typeorm';

@Entity()
@Unique(['FileNo'])
@Unique(['Save'])
export class File {
  @PrimaryGeneratedColumn() FileNo: number;
  @Column() Original: string;
  @Column() Save: string;
  @Column() OriImg: string;
  @Column() SaveImg: string;
  @CreateDateColumn() createdAt: string;
  @UpdateDateColumn() updatedAt: string;
  @DeleteDateColumn() deletedAt: string;
}
