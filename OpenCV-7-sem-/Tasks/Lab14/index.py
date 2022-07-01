import matplotlib.pyplot as plt
import matplotlib.image as mpimg
import numpy as np
import cv2

# 1
img_src = cv2.imread('./images/task1.jpg')
resized = cv2.resize(img_src, (600, 250), interpolation=cv2.INTER_AREA)
blur = cv2.GaussianBlur(resized, (7, 7), 0)
cv2.imshow('Original', blur)
imgray = cv2.cvtColor(blur, cv2.COLOR_BGR2GRAY)
ret, thresh = cv2.threshold(imgray, 127, 255, 0)
contours, hierarchy = cv2.findContours(thresh.copy(), cv2.RETR_TREE, cv2.CHAIN_APPROX_NONE)

cv2.drawContours(blur, contours, -1, (0, 255, 0), 2, cv2.LINE_AA, hierarchy, 3)
cv2.imshow("Contours", blur)


# 2
def draw_lines(img, houghLines, color=None, thickness=2):
    if color is None:
        color = [0, 255, 0]
    for line in houghLines:
        for rho, theta in line:
            a = np.cos(theta)
            b = np.sin(theta)
            x0 = a * rho
            y0 = b * rho
            x1 = int(x0 + 1000 * (-b))
            y1 = int(y0 + 1000 * a)
            x2 = int(x0 - 1000 * (-b))
            y2 = int(y0 - 1000 * a)

            cv2.line(img, (x1, y1), (x2, y2), color, thickness)


def weighted_img(img, initial_img, α=0.8, β=1., λ=0.):
    return cv2.addWeighted(initial_img, α, img, β, λ)


image = mpimg.imread("./images/task2.jpg")
gray_image = cv2.cvtColor(image, cv2.COLOR_RGB2GRAY)
blurred_image = cv2.GaussianBlur(gray_image, (9, 9), 0)
edges_image = cv2.Canny(blurred_image, 50, 120)

rho_resolution = 1
theta_resolution = np.pi / 180
threshold = 155

hough_lines = cv2.HoughLines(edges_image, rho_resolution, theta_resolution, threshold)

hough_lines_image = np.zeros_like(image)
draw_lines(hough_lines_image, hough_lines)
original_image_with_hough_lines = weighted_img(hough_lines_image, image)

plt.figure(figsize=(30, 20))
plt.subplot(131)
plt.imshow(image)
plt.subplot(132)
plt.imshow(edges_image, cmap='gray')
plt.subplot(133)
plt.imshow(original_image_with_hough_lines, cmap='gray')
plt.show()

# 3
img = cv2.imread('./images/task1.jpg', 0)
img = cv2.medianBlur(img, 5)
cimg = cv2.cvtColor(img, cv2.COLOR_GRAY2BGR)
circles = cv2.HoughCircles(img, cv2.HOUGH_GRADIENT, 1, 20, param1=100, param2=50, minRadius=0, maxRadius=0)
circles = np.uint16(np.around(circles))
for i in circles[0, :]:
    cv2.circle(cimg, (i[0], i[1]), i[2], (0, 255, 0), 2)
    cv2.circle(cimg, (i[0], i[1]), 2, (0, 0, 255), 3)
cv2.imshow('detected circles', cimg)

cv2.waitKey(0)
cv2.destroyAllWindows()
