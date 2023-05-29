import { Component, ElementRef, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FileUploadComponentParams } from 'src/app/shared/components/file-upload/models';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit, OnChanges {

  constructor() { }

  public fileName: string = '';

  @Input() params!: FileUploadComponentParams;
  @ViewChild('input') inputRef!: ElementRef<HTMLInputElement>;

  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes)
  }
  public ngOnInit(): void {
  }

  public onFileInput(event: Event) {
    this.fileName = this.inputRef?.nativeElement?.value.split('\\').pop() || '';
  }
}
