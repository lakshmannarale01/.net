import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'remarks'
})
export class RemarksPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    var count =(args[0]?? 10 as number)
    return (value as string).substring(0,55)+"..."+"---------  -------"+
     (value as string).substring(0,90)+"..."+"--  --"+  (value as string).substring(0,count as number)+"...";
    
  }

}
