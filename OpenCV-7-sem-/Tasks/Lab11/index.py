import cv2

img = cv2.imread('./image/my-pigs.jpg')
from matplotlib import pyplot as plt

resized = cv2.resize(img, (600, 250), interpolation=cv2.INTER_AREA)
cv2.imshow('original', resized)

gray_img = cv2.cvtColor(resized, cv2.COLOR_BGR2GRAY)
cv2.imshow('gray image', gray_img)
cv2.imwrite('./saved/gray.jpg', gray_img)

(thresh, black_and_white) = cv2.threshold(gray_img, 100, 255, cv2.THRESH_BINARY)
cv2.imshow('black & white', black_and_white)
cv2.imwrite('./saved/binary.jpg', black_and_white)

def flatHist(image):
    src = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    dst = cv2.equalizeHist(src)

    plt.figure(4)
    plt.subplot(221), plt.imshow(src), plt.title('Original Picture')
    plt.xticks([]), plt.yticks([])
    plt.subplot(222), plt.hist(src.ravel(), 256, [0, 256]), plt.title('Original Histogram')
    plt.xticks([]), plt.yticks([])

    plt.subplot(223), plt.imshow(dst), plt.title('Aligned Picture')
    plt.xticks([]), plt.yticks([])
    plt.subplot(224), plt.hist(dst.ravel(), 256, [0, 256]), plt.title('Aligned Histogram')
    plt.xticks([]), plt.yticks([])
    plt.show()

img2 = cv2.imread('./image/task4.jpg')
resized2 = cv2.resize(img2, (600, 250), interpolation=cv2.INTER_AREA)

flatHist(resized2)

cv2.waitKey(0)
cv2.destroyAllWindows()
