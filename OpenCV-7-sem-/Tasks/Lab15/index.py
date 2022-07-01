import cv2
import numpy as np

# Метод определения угла Харриса
image = cv2.imread('images/boot.jpg')
operatedImage = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
operatedImage = np.float32(operatedImage)
dest = cv2.cornerHarris(operatedImage, 2, 5, 0.07)
dest = cv2.dilate(dest, None)
image[dest > 0.01 * dest.max()] = [0, 0, 255]
cv2.imshow('Task1', image)

# Метод определения угла Ши Томаси
img2 = cv2.imread('images/boot.jpg')
gray = cv2.cvtColor(img2, cv2.COLOR_BGR2GRAY)
corners = cv2.goodFeaturesToTrack(gray, 100, 0.01, 10)
corners = np.int0(corners)
for i in corners:
    x, y = i.ravel()
    cv2.circle(img2, (x, y), 3, (255, 0, 0), -1)
cv2.imshow('Task2', img2)

# Афинное преобразование
FILE_NAME = './images/task3.jpg'

try:
    img = cv2.imread(FILE_NAME)
    (rows, cols) = img.shape[:2]

    M = cv2.getRotationMatrix2D((cols / 2, rows / 2), -90, 1)
    res = cv2.warpAffine(img, M, (cols, rows))

    cv2.imshow('Original image', img)
    cv2.imshow('Warp 90', res)

except IOError:
    print('Error while reading files !!!')

cv2.waitKey(0)
