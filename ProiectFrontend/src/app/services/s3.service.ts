// s3.service.ts

import { Injectable } from '@angular/core';
import * as AWS from 'aws-sdk';
import { environment } from '../environments/environments';

@Injectable({
  providedIn: 'root',
})
export class S3Service {
  private s3: AWS.S3;

  constructor() {
    this.s3 = new AWS.S3({
      accessKeyId: environment.awsAccessKeyId,
      secretAccessKey: environment.awsSecretAccessKey,
      region: environment.awsRegion,
    });
  }

  getObjectUrl(bucket: string, key: string): string {
    return this.s3.getSignedUrl('getObject', {
      Bucket: bucket,
      Key: key,
    });
  }
}
