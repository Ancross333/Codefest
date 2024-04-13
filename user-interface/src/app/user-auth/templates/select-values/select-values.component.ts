import { NgFor } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-select-values', 
  standalone: true,
  imports: [NgFor],
  templateUrl: './select-values.component.html',
  styleUrls: ['./select-values.component.css']
})
export class SelectValuesComponent {
  public values: string[];
  selectedValues: number[] = [];

  constructor(
    public dialogRef: MatDialogRef<SelectValuesComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.values = data.values; 
  }

  onCheckboxChange(event: Event, value: string): void {
    const checkbox = event.target as HTMLInputElement;
    const index = this.values.indexOf(value);
    if (checkbox.checked) {
      if (!this.selectedValues.includes(index)) {
        this.selectedValues.push(index);
      }
    } else {
      const idx = this.selectedValues.indexOf(index);
      if (idx > -1) {
        this.selectedValues.splice(idx, 1);
      }
    }
  }

  confirmSelection(): void {
    this.dialogRef.close(this.selectedValues);
  }
}
