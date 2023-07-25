package com.daviddev16;

import java.io.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.List;
import java.util.Objects;
import java.util.zip.*;

public class Launcher {

    public static int fileCounter = 0;

    public static void main(String[] args) throws IOException {

        System.out.println("\n");

        if (args.length < 1) {
            System.out.println("Não foi informado um diretório.");
            return;
        }

        File directory = new File(args[0]);

        if (!directory.isDirectory()) {
            System.out.println("O caminho informado não é um diretório.");
            return;
        }

        List<File> corruptedFiles = new ArrayList<>();
        File tempFile = File.createTempFile("shop-analyzer-buffer", null,
                new File(System.getProperty("user.home")));
        tempFile.deleteOnExit();

        analyzeDirectory(directory, tempFile, corruptedFiles);
        corruptedFiles.forEach(corruptedFile -> System.out.println("ERRO: " +
                corruptedFile.getAbsolutePath()));

        System.out.println("\n");
        System.out.println("Foi analisado " + fileCounter + " arquivos.");
        System.out.println("\n");

    }

    public static boolean analyzeFile(File checkedFile, File tempFile) {
        try {
            fileCounter++;
            ZipFile zipFile = new ZipFile(checkedFile);
            Enumeration<? extends ZipEntry> zipEntries = zipFile.entries();
            while (zipEntries.hasMoreElements()) {
                ZipEntry zipEntry = zipEntries.nextElement();
                InputStream zipInputStream = zipFile.getInputStream(zipEntry);
                BufferedReader bufferedReader = new BufferedReader( new InputStreamReader(zipInputStream));
                String line;
                while ((line = bufferedReader.readLine()) != null) {
                    Files.write(Paths.get(tempFile.toURI()), line.getBytes(
                            StandardCharsets.ISO_8859_1), StandardOpenOption.WRITE);
                }
                bufferedReader.close();
            }
            zipFile.close();
            return true;
        } catch (IOException e) {
            return false;
        }

    }

    public static void analyzeDirectory(File directory, File tempFile, List<File> corruptedFiles) {
        for (File file : Objects.requireNonNull(directory.listFiles())) {
            if (file.isDirectory()) {
                analyzeDirectory(file, tempFile, corruptedFiles);
                continue;
            }
            if (!analyzeFile(file, tempFile))
                corruptedFiles.add(file);
        }
    }

}
