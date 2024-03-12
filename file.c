#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

// Функция за извършване на корекция според зададените правила
void applyCorrection(char *buffer, size_t size) {
    for (size_t i = 0; i < size; ++i) {
        // Шаблон 1: Премахване на интервал между дума и многоточие
        if (buffer[i] == '.' && buffer[i + 1] == '.' && isalnum(buffer[i + 2])) {
            // Премахване на интервал след многоточие
            memmove(buffer + i + 2, buffer + i + 3, strlen(buffer + i + 3) + 1);
        }

        // Шаблон 2: Премахване на ненужна точка
        if (buffer[i] == '.' && buffer[i + 1] == '.' && buffer[i + 2] == '.' && buffer[i + 3] == '.') {
            // Заместване на повече от три точки с три точки
            memmove(buffer + i + 3, buffer + i + 4, strlen(buffer + i + 4) + 1);
        }

        // Шаблон 3: Корекция на неправилно пренесен ред при пряка реч
        if (buffer[i] == ',' && buffer[i + 1] == '\n') {
            // Премахване на нов ред след запетая
            memmove(buffer + i + 1, buffer + i + 2, strlen(buffer + i + 2) + 1);
        } else if (buffer[i] == '-' && buffer[i + 1] == '\n') {
            // Премахване на нов ред след тире
            memmove(buffer + i + 1, buffer + i + 2, strlen(buffer + i + 2) + 1);
        }

        // Шаблон 4: Премахване на интервали между препинателни знаци
        if (ispunct(buffer[i]) && buffer[i + 1] == ' ' && ispunct(buffer[i + 2])) {
            // Премахване на интервалите между препинателни знаци
            memmove(buffer + i + 1, buffer + i + 2, strlen(buffer + i + 2) + 1);
        }

        // Шаблон 5: Премахване на интервал пред препинателен знак
        if (buffer[i] == ' ' && ispunct(buffer[i + 1])) {
            // Премахване на интервала пред препинателен знак
            memmove(buffer + i, buffer + i + 1, strlen(buffer + i + 1) + 1);
        }

        // Шаблон 6: Премахване на ',' от препимателен знак
        if (buffer[i] == ',' && ispunct(buffer[i + 1]) && buffer[i + 2] == ' ') {
            // Премахване на ',' и интервалът след него
            memmove(buffer + i, buffer + i + 2, strlen(buffer + i + 2) + 1);
        }
        if (buffer[i] == ',' && buffer[i + 1] == ' ' && ispunct(buffer[i + 2])) {
            // Премахване на ',' и интервалът преди него
            memmove(buffer + i, buffer + i + 1, strlen(buffer + i + 1) + 1);
        }
        if (buffer[i] == ',' && ispunct(buffer[i + 1]) && ispunct(buffer[i + 2])) {
            // Премахване на ',' и интервалите след него
            memmove(buffer + i, buffer + i + 1, strlen(buffer + i + 1) + 1);
        }

        // Шаблон 7: Добавяне на интервал между ',' и печатим символ
        if (buffer[i] == ',' && isalnum(buffer[i + 1])) {
            // Добавяне на интервал след ','
            memmove(buffer + i + 2, buffer + i + 1, strlen(buffer + i + 1) + 1);
            buffer[i + 1] = ' ';
        }

        // Шаблон 8: Премахване на интервали между препинателни знаци
        // ...

        // Шаблон 9: Премахване на ',' след начална дума в изречението
        if (buffer[i] == ',' && ispunct(buffer[i + 1]) && isalpha(buffer[i + 2])) {
            // Премахване на ','
            memmove(buffer + i, buffer + i + 1, strlen(buffer + i + 1) + 1);
        }

        // Шаблон 10: Задължителна ',' след начална дума в изречението
        if (isalnum(buffer[i]) && buffer[i + 1] == ' ' && ispunct(buffer[i + 2]) && isalpha(buffer[i + 3])) {
            // Вмъкване на ','
            memmove(buffer + i + 2, buffer + i + 1, strlen(buffer + i + 1) + 1);
            buffer[i + 1] = ',';
        }
        
        // Шаблон 11: Задължителна ',' пред и след дума
        if (isalnum(buffer[i]) && buffer[i + 1] == ' ' && isalpha(buffer[i + 2]) && buffer[i + 3] == ' ' && isalnum(buffer[i + 4])) {
            // Вмъкване на ',' пред и след дума
            memmove(buffer + i + 3, buffer + i + 2, strlen(buffer + i + 2) + 1);
            buffer[i + 2] = ',';
        }

        // Шаблон 12: Премахване на ',' след съюз
        if (isalpha(buffer[i]) && buffer[i + 1] == ',' && isalpha(buffer[i + 2]) && buffer[i + 3] == ' ') {
            // Премахване на ','
            memmove(buffer + i + 1, buffer + i + 2, strlen(buffer + i + 2) + 1);
        }

        // Шаблон 13: Преместване на ','
        if (isalpha(buffer[i]) && buffer[i + 1] == ',' && buffer[i + 2] == ' ' && isalpha(buffer[i + 3])) {
            // Преместване на ','
            memmove(buffer + i + 2, buffer + i + 1, strlen(buffer + i + 1) + 1);
            buffer[i + 1] = ',';
        }

        // Шаблон 14: Премахване на ',' след уточняващо наречие
        if (isalpha(buffer[i]) && buffer[i + 1] == ',' && isalpha(buffer[i + 2]) && buffer[i + 3] == ' ' && isalpha(buffer[i + 4])) {
            // Премахване на ','
            memmove(buffer + i + 1, buffer + i + 2, strlen(buffer + i + 2) + 1);
        }

        // Шаблон 15: Добавяне на ','
        if (isalpha(buffer[i]) && buffer[i + 1] == ' ' && strncmp(buffer + i + 2, "не", 2) == 0 && buffer[i + 4] == ' ' && isalpha(buffer[i + 5])) {
            // Добавяне на ','
            memmove(buffer + i + 4, buffer + i + 3, strlen(buffer + i + 3) + 1);
            buffer[i + 3] = ',';
        }
        // Шаблон 16: Добавяне на ','
        if (isalpha(buffer[i]) && buffer[i + 1] == ' ' && strncmp(buffer + i + 2, "За съжаление", 13) == 0 && buffer[i + 15] == ' ' && isalpha(buffer[i + 16])) {
            // Добавяне на ','
            memmove(buffer + i + 15, buffer + i + 14, strlen(buffer + i + 14) + 1);
            buffer[i + 14] = ',';
        }

        // Шаблон 17: Премахване на ','
        if (isalpha(buffer[i]) && buffer[i + 1] == ' ' && strncmp(buffer + i + 2, "за да", 5) == 0 && buffer[i + 7] == ',') {
            // Премахване на ','
            memmove(buffer + i + 6, buffer + i + 7, strlen(buffer + i + 7) + 1);
        }

        // Шаблон 18: Премахване на ',' пред 'че'
        if (isalpha(buffer[i]) && buffer[i + 1] == ' ' && strncmp(buffer + i + 2, "че", 2) == 0) {
            // Премахване на ','
            memmove(buffer + i + 1, buffer + i + 2, strlen(buffer + i + 2) + 1);
        }

        // Шаблон 19: Премахване на ','
        if (strncmp(buffer + i, "че,", 3) == 0) {
            // Премахване на ','
            memmove(buffer + i + 2, buffer + i + 3, strlen(buffer + i + 3) + 1);
        }

        // Шаблон 20: Добавяне на ','
        if (isalpha(buffer[i]) && buffer[i + 1] == ' ' && strncmp(buffer + i + 2, "като", 4) == 0) {
            // Добавяне на ','
            memmove(buffer + i + 4, buffer + i + 3, strlen(buffer + i + 3) + 1);
            buffer[i + 3] = ',';
        }
         // Шаблон 21: Добавяне на ','
        if (isalpha(buffer[i]) && buffer[i + 1] == ' ' && strncmp(buffer + i + 2, "като следва", 12) == 0 && buffer[i + 14] == ' ' && isalpha(buffer[i + 15])) {
            // Добавяне на ','
            memmove(buffer + i + 14, buffer + i + 13, strlen(buffer + i + 13) + 1);
            buffer[i + 13] = ',';
        }

        // Шаблон 22: Премахване на ',' пред 'естествено'
        if (strncmp(buffer + i, "естествено,", 11) == 0) {
            // Премахване на ','
            memmove(buffer + i + 10, buffer + i + 11, strlen(buffer + i + 11) + 1);
        }

        // Шаблон 23: Кога се слага 'във'
        if (buffer[i] == 'в' && buffer[i + 1] == ' ' && buffer[i + 2] == 'в' && buffer[i + 3] == ' ') {
            // Заместване на 'в' с 'във'
            memmove(buffer + i + 1, buffer + i + 2, strlen(buffer + i + 2) + 1);
            buffer[i + 1] = 'ъ';
        }

        // Шаблон 24: Кога се слага 'със'
        if (buffer[i] == 'с' && buffer[i + 1] == ' ' && buffer[i + 2] == 'с' && buffer[i + 3] == ' ') {
            // Заместване на 'с' с 'със'
            memmove(buffer + i + 1, buffer + i + 2, strlen(buffer + i + 2) + 1);
            buffer[i + 1] = 'ъ';
        }

        // Шаблон 25: Добавяне на ','
        if (isalpha(buffer[i]) && buffer[i + 1] == ' ' && strncmp(buffer + i + 2, "иначе", 5) == 0 && buffer[i + 7] == ' ' && isalpha(buffer[i + 8])) {
            // Добавяне на ','
            memmove(buffer + i + 7, buffer + i + 6, strlen(buffer + i + 6) + 1);
            buffer[i + 6] = ',';
        }
    }
}

int main() {

    FILE *inputFile = fopen("input.txt", "r");
    FILE *outputFile = fopen("output.txt", "w");

    if (!inputFile || !outputFile) {
        perror("Грешка при отваряне на файл");
        return 1;
    }

    fseek(inputFile, 0, SEEK_END);
    size_t fileSize = ftell(inputFile);
    fseek(inputFile, 0, SEEK_SET);

    char *buffer = (char *)malloc(fileSize + 1);

    if (!buffer) {
        perror("Грешка при заделяне на памет");
        return 1;
    }

    fread(buffer, 1, fileSize, inputFile);
    buffer[fileSize] = '\0';

    applyCorrection(buffer, fileSize);

    fprintf(outputFile, "%s", buffer);

    fclose(inputFile);
    fclose(outputFile);

    free(buffer);

    return 0;
}
