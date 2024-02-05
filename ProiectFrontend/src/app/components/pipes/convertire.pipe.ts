import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertire',
  standalone: true
})
export class ConvertirePipe implements PipeTransform {

  transform(value: number, format: string = 'yyyy-MM-dd HH:mm:ss'): string {
    const timp = new Date(value * 1000); //convertire timp
    const formatTimp: Intl.DateTimeFormatOptions = {
      year: 'numeric',
      month: '2-digit',
      day: '2-digit',
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit'
    };

    return new Intl.DateTimeFormat('en-US', formatTimp).format(timp);
  }
}
