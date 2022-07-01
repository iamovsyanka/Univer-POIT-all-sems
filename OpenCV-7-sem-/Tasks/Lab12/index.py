import cv2
import numpy as np
from matplotlib import pyplot as plt

# Task1
img_src = cv2.imread('images/task1.png')
resized = cv2.resize(img_src, (600, 250), interpolation=cv2.INTER_AREA)
kernel = np.array([[1, 1, 1, 1, 1], [1, 1, 1, 1, 1], [1, 1, 1, 1, 1], [1, 1, 1, 1, 1], [1, 1, 1, 1, 1]])
kernel = kernel / sum(kernel)
img_rst = cv2.filter2D(resized, -1, kernel)
cv2.imshow('task1', img_rst)

# Task2
image2 = cv2.imread('images/task2.jpg')
resized2 = cv2.resize(image2, (600, 250), interpolation=cv2.INTER_AREA)

plt.figure(1)
iblur = cv2.blur(resized2, (11, 11))
iboxFilter = cv2.boxFilter(resized2, -1, (11, 11), image2, (-1, -1), True, cv2.BORDER_DEFAULT)
igaussianBlur = cv2.GaussianBlur(resized2, (11, 11), 0)
imedianBlur = cv2.medianBlur(resized2, 11)
plt.subplot(221), plt.imshow(iblur), plt.title('Blur')
plt.xticks([]), plt.yticks([])
plt.subplot(222), plt.imshow(iboxFilter), plt.title('Box Filter')
plt.xticks([]), plt.yticks([])
plt.subplot(223), plt.imshow(igaussianBlur), plt.title('Gaussian Blur')
plt.xticks([]), plt.yticks([])
plt.subplot(224), plt.imshow(imedianBlur), plt.title('Median Blur')
plt.xticks([]), plt.yticks([])
plt.gcf().canvas.manager.set_window_title('Second task')
plt.show()

# Task3
kernel1 = np.ones((5, 5), np.uint8)


def erosion(image):
    gray_img = cv2.cvtColor(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA), cv2.COLOR_BGR2GRAY)
    (thresh, black_and_white) = cv2.threshold(gray_img, 127, 255, cv2.THRESH_BINARY)
    result = cv2.erode(black_and_white, kernel1, iterations=1)
    return result


def dilatation(image):
    gray_img = cv2.cvtColor(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA), cv2.COLOR_BGR2GRAY)
    (thresh, black_and_white) = cv2.threshold(gray_img, 127, 255, cv2.THRESH_BINARY)
    result = cv2.dilate(black_and_white, kernel1, iterations=1)
    return result


# Task4
kernel1 = np.ones((5, 5), np.uint8)


def erosion(image):
    gray_img = cv2.cvtColor(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA), cv2.COLOR_BGR2GRAY)
    (thresh, black_and_white) = cv2.threshold(gray_img, 127, 255, cv2.THRESH_BINARY)
    result = cv2.erode(black_and_white, kernel1, iterations=1)
    return result


def dilatation(image):
    gray_img = cv2.cvtColor(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA), cv2.COLOR_BGR2GRAY)
    (thresh, black_and_white) = cv2.threshold(gray_img, 127, 255, cv2.THRESH_BINARY)
    result = cv2.dilate(black_and_white, kernel1, iterations=1)
    return result


def Difference1(image):
    gray_img = cv2.cvtColor(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA), cv2.COLOR_BGR2GRAY)
    (thresh, black_and_white) = cv2.threshold(gray_img, 127, 255, cv2.THRESH_BINARY)
    ibe = cv2.erode(black_and_white, kernel1, iterations=1)
    result = np.subtract(black_and_white, ibe)
    return result


def Difference2(image):
    gray_img = cv2.cvtColor(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA), cv2.COLOR_BGR2GRAY)
    (thresh, black_and_white) = cv2.threshold(gray_img, 127, 255, cv2.THRESH_BINARY)
    ibe = cv2.dilate(black_and_white, kernel1, iterations=1)
    result = np.subtract(black_and_white, ibe)
    return result


def main():
    image = cv2.imread('images/task2.jpg')

    plt.figure(2)
    erode = erosion(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA))
    dilate = dilatation(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA))
    plt.subplot(121), plt.imshow(erode), plt.title('Erosion')
    plt.xticks([]), plt.yticks([])
    plt.subplot(122), plt.imshow(dilate), plt.title('Dilatation')
    plt.xticks([]), plt.yticks([])
    plt.gcf().canvas.manager.set_window_title('Third task')
    plt.show()

    plt.figure(3)
    differ = Difference1(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA))
    differ2 = Difference2(cv2.resize(image, (600, 250), interpolation=cv2.INTER_AREA))
    plt.subplot(221), plt.imshow(differ), plt.title('Difference erosion')
    plt.xticks([]), plt.yticks([])
    plt.subplot(222), plt.imshow(differ2), plt.title('Difference dilatation')
    plt.xticks([]), plt.yticks([])
    plt.subplot(223), plt.imshow(erode), plt.title('Erosion')
    plt.xticks([]), plt.yticks([])
    plt.subplot(224), plt.imshow(dilate), plt.title('Dilatation')
    plt.xticks([]), plt.yticks([])
    plt.gcf().canvas.manager.set_window_title('Fourth task')
    plt.show()


main()

cv2.waitKey(0)
cv2.destroyAllWindows()
